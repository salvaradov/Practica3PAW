namespace Practica3PrograAvW_WEB.Models
{
    public class Producto
    {
        public long IdCompra { get; set; }
        public double Precio { get; set; }
        public double Saldo { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
