
namespace Core.Models
{
    /// <summary>
    /// Clase base para los modelos de clasificadores
    /// </summary>
    public abstract class BaseClassifierModel: ICacheStorable
    {
        protected BaseClassifierModel()
        {
        }


        /// <summary>
        /// Id del clasificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del clasificador
        /// </summary>
        public string Name { get; set; }

    }
}
