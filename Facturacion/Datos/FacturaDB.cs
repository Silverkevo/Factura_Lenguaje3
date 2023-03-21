using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Datos
{
    public class FacturaDB
    {
        string cadena = "server=localhost; user=root; database=mifactura; password=madrid77";

        public bool Guardar(Factura factura, List<DetalleFactura> detalles)
        {
            bool inserto = false;
            int idfactura = 0;
            try
            {
                StringBuilder sqlFactura = new StringBuilder();
                sqlFactura.Append(" INSERT INTO factura VALUES  (@Fecha,@IdentidadCliente,@CodigoUsuario,@ISV,@Descuento,@Subtotal,@Total);");
                sqlFactura.Append(" SELECT LAST_INSERT_ID();");

                StringBuilder sqlDetalle = new StringBuilder();
                sqlDetalle.Append(" INSERT INTO detallefactura (@IdFactura, @CodigoProducto, @Precio, @Cantidad, @Total);");

                StringBuilder sqlExistencia = new StringBuilder();
                sqlExistencia.Append(" UPDATE producto SET Existencia = Existencia - @Cantidad WHERE Codigo = @Codigo; ");

                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    con.Open();

                    MySqlTransaction tran = con.BeginTransaction((System.Data.IsolationLevel)IsolationLevel.ReadCommitted);

                    using (MySqlCommand cmd1 = new MySqlCommand(sqlFactura.ToString(), con, tran))
                    {
                        cmd1.CommandType = System.Data.CommandType.Text;
                        cmd1.Parameters.Add("@Fecha", MySqlDbType.Datetime).Value = factura.Fecha;

                    }

                }

            }
            catch (Exception)
            {
            }
            return inserto;
        }
    }
}
