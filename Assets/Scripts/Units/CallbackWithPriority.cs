public class CallbackWithPriority
{
    public readonly int priority;
    public readonly object callback;
    public CallbackWithPriority(int priority, object callback)
    {
        this.priority = priority;
        this.callback = callback;
    }
}
