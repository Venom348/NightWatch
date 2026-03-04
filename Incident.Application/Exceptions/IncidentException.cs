namespace Incident.Application.Exceptions;

/// <summary>
///     Класс для вывода ошибки
/// </summary>
/// <param name="msg">Сообщение ошибки</param>
public class IncidentException(string msg = "") : Exception(msg);