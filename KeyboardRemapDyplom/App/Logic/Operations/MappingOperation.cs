namespace App.Logic.Operations
{
    public class MappingOperation : Operation
    {
        public int MappedKey { get; set; }

        public int SourceKey { get; set; }

        public override void Reset()
        {
            base.Reset();

            this.SourceKey = 0;
            this.MappedKey = 0;
        }
    }
}