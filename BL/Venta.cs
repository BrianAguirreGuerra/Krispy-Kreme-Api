using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DL;

namespace BL
{
    public class Venta
    {
        public static ML.Result Add(decimal Total)
        {
            try
            {
                using (DL.KrispyKremeContext context = new DL.KrispyKremeContext())
                {
                    Ventum nuevaVenta = new Ventum
                    {
                        IdCliente = 1,
                        Total = Total,
                        Fecha = DateTime.Now
                    };

                    context.Venta.Add(nuevaVenta);
                    context.SaveChanges();
                }

                return new ML.Result { Correct = true };
            }
            catch (Exception ex)
            {
                return new ML.Result
                {
                    Correct = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public static ML.Result GetAll()
        {
            try
            {
                using (DL.KrispyKremeContext context = new DL.KrispyKremeContext())
                {
                    var ventas = context.Venta.ToList();
                    var ventasObj = ventas.Cast<object>().ToList();

                    return new ML.Result
                    {
                        Correct = true,
                        Objects = ventasObj
                    };
                }
            }
            catch (Exception ex)
            {
                return new ML.Result
                {
                    Correct = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public static ML.Result GetById(int idVenta)
        {
            try
            {
                using (DL.KrispyKremeContext context = new DL.KrispyKremeContext())
                {
                    var venta = context.Venta.FirstOrDefault(v => v.IdVenta == idVenta);

                    if (venta != null)
                    {
                        return new ML.Result
                        {
                            Correct = true,
                            Object = venta
                        };
                    }
                    else
                    {
                        return new ML.Result
                        {
                            Correct = false,
                            ErrorMessage = "Venta no encontrada"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ML.Result
                {
                    Correct = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
