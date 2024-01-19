namespace recipesv2.Helpers
{
    public class OperationCompleted<T>
    {
        public bool Completed { get; set; } = false;

        public T? Payload { get; set; }
    }
}
