namespace EFCorePossibleBugPOC
{
    public class ZLast : IEntityWithChild
    {
        public int Id { get; set; }
        public int? MiddleId { get; set; }
        public virtual Middle Middle { get; set; }
        public string Bar { get; set; }
    }

    public class ZLast2 : IEntityWithChild
    {
        public int Id { get; set; }
        public int? MiddleId { get; set; }
        public virtual Middle Middle { get; set; }
        public string Bar { get; set; }
    }

    public class ZLast3 : IEntityWithChild
    {
        public int Id { get; set; }
        public int? MiddleId { get; set; }
        public virtual Middle Middle { get; set; }
        public string Bar { get; set; }
    }
}
