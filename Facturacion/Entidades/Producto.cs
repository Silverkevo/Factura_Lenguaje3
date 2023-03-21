namespace Entidades
{
    public class Producto
    {
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int Exisencia { get; set; }

        public decimal Precio { get; set; }

        public byte[] Foto { get; set; }

        public bool EstaActivo { get; set; }

        public Producto()
        {
        }

        public Producto(string codigo, string descripcion, int exisencia, decimal precio, byte[] foto, bool estaActivo)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Exisencia = exisencia;
            Precio = precio;
            Foto = foto;
            EstaActivo = estaActivo;
        }
    }
}
