namespace EFCorePossibleBugPOC3._1
{
    public class First : IEntityWithChild
    {
        public int Id { get; set; }
        public int? MiddleId { get; set; }
        public virtual Middle Middle { get; set; }
        public string Bar { get; set; }
    }

    public class First2 : IEntityWithChild
    {
        public int Id { get; set; }
        public int? MiddleId { get; set; }
        public virtual Middle Middle { get; set; }
        public string Bar { get; set; }
    }

    public class First3 : IEntityWithChild
    {
        public int Id { get; set; }
        public int? MiddleId { get; set; }
        public virtual Middle Middle { get; set; }
        public string Bar { get; set; }
    }
}
