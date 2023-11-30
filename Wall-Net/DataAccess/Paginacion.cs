using Microsoft.EntityFrameworkCore;

namespace Wall_Net.DataAccess
{
    public class Paginacion<T> : List<T>
    {
        public int PaginaInicio { get; set; }
        public int PaginasTotales { get; set; }

        public Paginacion(List<T> items, int contador, int paginaInicio, int cantidadRegistros)
        {
            PaginaInicio = paginaInicio;
            PaginasTotales = (int)Math.Ceiling(contador / (double)cantidadRegistros);

            this.AddRange(items);
        }

        public bool PaginasAnteriores => PaginaInicio > 1;
        public bool PaginasPosteriores => PaginaInicio < PaginaInicio;

        public static async Task<Paginacion<T>> CrearPaginacion(IEnumerable<T> fuente, int paginaInicio, int cantidadRegistros)
        {
            var contador = fuente.Count();
            var items = fuente.Skip((paginaInicio - 1) * cantidadRegistros).Take(cantidadRegistros).ToList();
            return new Paginacion<T>(items, contador, paginaInicio, cantidadRegistros);
        }
    }
}