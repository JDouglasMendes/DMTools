namespace DMTools.Clone
{
    public interface ICloneable<out T>
    {
        T Clone();
    }
}
