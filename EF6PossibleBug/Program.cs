using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;

namespace EF6PossibleBug
{
    class Program
    {
        private static DemoDbContext _ctx;
        private static string _failedScenarios = "";
        private static string _succeededScenarios = "";

        static void Main(string[] args)
        {
            InitializeDbData();

            RunScenarion(Scenario1);
            RunScenarion(Scenario2);
            RunScenarion(Scenario3);
            RunScenarion(Scenario4);
            RunScenarion(Scenario5);
            RunScenarion(Scenario6);

            Console.WriteLine($"Failed scenarios: {_failedScenarios}");
            Console.WriteLine($"OK scenarios: {_succeededScenarios}");

            Console.ReadKey();
        }

        static void InitializeDbData()
        {
            using (_ctx = new DemoDbContext())
            {
                ClearData();
                CreateDemoData();
                Console.Clear();
            }
        }

        private static void CreateDemoData()
        {
            _ctx.Firsts.Add(new First
            {
                Bar = "First_Firsts",
                Middle = new Middle
                {
                    Foo = "First_Firsts_Middle"
                }
            });

            _ctx.ZFirst2s.Add(new First2
            {
                Bar = "First2_ZFirst2s",
                Middle = new Middle
                {
                    Foo = "First2_ZFirst2s_Middle"
                }
            });

            _ctx.AZLast2s.Add(new ZLast2
            {
                Bar = "Zlast2_AZLast2s",
                Middle = new Middle
                {
                    Foo = "ZLast2_AZLast2s_Middle"
                }
            });

            _ctx.ZLasts.Add(new ZLast
            {
                Bar = "ZLast_ZLasts",
                Middle = new Middle
                {
                    Foo = "ZLast_ZLasts_Middle"
                }
            });

            _ctx.First3s.Add(new First3
            {
                Bar = "First3_ZFirst3s",
                Middle = new Middle
                {
                    Foo = "First3_ZFirst3s_Middle"
                }
            });

            _ctx.ZLast3s.Add(new ZLast3
            {
                Bar = "ZLast3_AZLast3s",
                Middle = new Middle
                {
                    Foo = "ZLast3_AZLast3s_Middle"
                }
            });

            _ctx.SaveChanges();
        }

        static void ClearData()
        {
            _ctx.AZLast2s.RemoveRange(_ctx.AZLast2s);
            _ctx.Firsts.RemoveRange(_ctx.Firsts);
            _ctx.ZFirst2s.RemoveRange(_ctx.ZFirst2s);
            _ctx.ZLasts.RemoveRange(_ctx.ZLasts);
            _ctx.ZLast3s.RemoveRange(_ctx.ZLast3s);
            _ctx.First3s.RemoveRange(_ctx.First3s);
            _ctx.Middles.RemoveRange(_ctx.Middles);
            _ctx.SaveChanges();
        }

        static void RunScenarion(Action scenarioAction)
        {
            using (_ctx = new DemoDbContext())
            {
                var hadError = false;
                try
                {
                    scenarioAction();
                }
                catch (Exception ex) when (ex.InnerException != null && ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n### {scenarioAction.Method.Name} failed ###\n");
                    _failedScenarios += $" {scenarioAction.Method.Name}";
                    hadError = true;
                }
                finally
                {
                    if (!hadError)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"\n### {scenarioAction.Method.Name} succeeded ###\n");
                        _succeededScenarios += $" {scenarioAction.Method.Name}";
                    }
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // Main table name: Firsts
        // Scenario: succeeds 
        static void Scenario1()
        {
            BuildScenario<First>(
                () => _ctx.Firsts.AsNoTracking().FirstOrDefault(),
                (id) => _ctx.Firsts.Where(x => x.Id == id).Select(x => x.Middle).FirstOrDefault()
            );
        }

        // Main table name: ZLasts
        // Scenario: succeeds 
        static void Scenario2()
        {
            BuildScenario<ZLast>(
                () => _ctx.ZLasts.AsNoTracking().FirstOrDefault(),
                (id) => _ctx.ZLasts.Where(x => x.Id == id).Select(x => x.Middle).FirstOrDefault()
            );
        }

        // Main table name: ZFirst2s
        // Scenario: succeeds 
        static void Scenario3()
        {
            BuildScenario<First2>(
                () => _ctx.ZFirst2s.AsNoTracking().FirstOrDefault(),
                (id) => _ctx.ZFirst2s.Where(x => x.Id == id).Select(x => x.Middle).FirstOrDefault()
            );
        }

        // Main table name: AZLast2s
        // Scenario: succeeds 
        static void Scenario4()
        {
            BuildScenario<ZLast2>(
                () => _ctx.AZLast2s.AsNoTracking().FirstOrDefault(),
                (id) => _ctx.AZLast2s.Where(x => x.Id == id).Select(x => x.Middle).FirstOrDefault()
            );
        }

        // Main table name: ZFirst3s
        // Scenario: succeeds 
        static void Scenario5()
        {
            BuildScenario<First3>(
                () => _ctx.First3s.AsNoTracking().FirstOrDefault(),
                (id) => _ctx.First3s.Where(x => x.Id == id).Select(x => x.Middle).FirstOrDefault()
            );
        }

        // Main table name: AZLast3s
        // Scenario: succeeds 
        static void Scenario6()
        {
            BuildScenario<ZLast3>(
                () => _ctx.ZLast3s.AsNoTracking().FirstOrDefault(),
                (id) => _ctx.ZLast3s.Where(x => x.Id == id).Select(x => x.Middle).FirstOrDefault()
            );
        }

        static void BuildScenario<TEntity>(Func<TEntity> getNonTrackedEntity, Func<int, Middle> getAssociatedChild) 
            where TEntity : class, IEntityWithChild, new()
        {
            // Simulate update from a web call
            var entity = getNonTrackedEntity();

            entity.Middle = null;
            entity.MiddleId = null;

            // Since child got removed, I need to get the old one to remove it
            var toRemove = getAssociatedChild(entity.Id);

            _ctx.Set<TEntity>().Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;

            _ctx.Set<Middle>().Remove(toRemove);

            _ctx.SaveChanges();
        }
    }
}
