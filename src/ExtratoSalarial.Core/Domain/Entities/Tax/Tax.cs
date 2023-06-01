namespace ExtratoSalarial.Core.Domain.Entities.Tax
{
    public abstract class Tax
    {
        public abstract decimal Calculate(Employee employee);
    }
}
