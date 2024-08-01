using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Marca marca)
        {
            var marcaDb = _db.Marcas.FirstOrDefault(x => x.Id == marca.Id);

            if (marcaDb != null)
            {
                marcaDb.Nombre = marca.Nombre;
                marcaDb.Descripcion = marca.Descripcion;
                marcaDb.Estado = marca.Estado;
                _db.SaveChanges();
            }
        }
    }
}
