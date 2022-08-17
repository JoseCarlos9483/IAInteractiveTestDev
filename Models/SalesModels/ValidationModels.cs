namespace Models.SalesModels
{
    /// <summary>
    /// Clase para validar metodos
    /// </summary>
    public class ValidationModels
    {
        /// <summary>
        /// Constructor para dar valor a las propiedades
        /// </summary>
        public ValidationModels()
        {
            Succes = true;
        }

        /// <summary>
        /// Si cumple con los criterios
        /// </summary>
        public bool Succes { get; set; }

        /// <summary>
        /// Mensaje para el front
        /// </summary>
        public string? Message { get; set; }
    }
}
