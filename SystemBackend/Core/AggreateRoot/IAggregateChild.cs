﻿namespace Core.AggreateRoot
{
    /// <summary>
    /// Interfaz para marcar las entidades hijas de los agregados
    /// </summary>
    /// <typeparam name="TRoot">Entidad root del agregado</typeparam>
    public interface IAggregateChild<TRoot> where TRoot : IAggregateRoot
    {
    }
}
