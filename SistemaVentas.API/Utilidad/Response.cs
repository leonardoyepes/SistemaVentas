namespace SistemaVentas.API.Utilidad
{
    public class Response<T>
    {
        public bool State {  get; set; }
        public T Vaule {  get; set; }
        public string? Mesagge {  get; set; }
    }
}
