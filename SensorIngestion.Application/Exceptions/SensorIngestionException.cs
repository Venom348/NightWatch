namespace SensorIngestion.Application.Exceptions;

/// <summary>
///     Класс для вывода ошибки
/// </summary>
/// <param name="msg">Сообщение ошибки</param>
public class SensorIngestionException(string msg = "") :  Exception(msg);