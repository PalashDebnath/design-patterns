/*
  Demonstration of single responsibility principle(SRP)/separation of concern.

  Here VJournal is doing this beyond it's responsibility/concern. It is not only taking care of entries list,
  also takeing care of saving those and logging errors. Which in this case violate the 'S' of SOLID principle.

  On the other hand the Journal class follows single responsibility principle/separation of concern by delegating
  the error logging and saving responsibility to other class. 
*/
namespace DesignPatterns.SingleResponsibilityPrinciple;

public enum LOGTYPE { ERROR, INFO, WARNING, TRACE }

public class VJournal
{
  private readonly List<string> entries = new List<string>();
  private static int count = 0;
  public int AddEntry(string content)
  {
    try
    {
      entries.Add($"{++count}: {content}");
    }
    catch (Exception ex)
    {
      File.WriteAllTextAsync(@"c:\ErrorLog.txt", ex.ToString());
    }
    return count;
  }
  public void RemoveEntry(int index)
  {
    try
    {
      entries.RemoveAt(index);
    }
    catch (Exception ex)
    {
      File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
    }
  }

  public override string ToString()
  {
    return string.Join(Environment.NewLine, entries);
  }
}

public class Journal
{
  private int count;
  private readonly List<string> entries;
  private readonly Logger logger;
  public Journal()
  {
    entries = new List<string>();
    logger = new Logger(@"c:\temp\logger.txt");
  }
  public int AddEntry(string text)
  {
    try
    {
      entries.Add($"{++count}: {text}");
      logger.Log($"Added '{text}' to the journal", LOGTYPE.TRACE);
    }
    catch (Exception ex)
    {
      logger.Log(ex.ToString(), LOGTYPE.ERROR);
    }
    return count;
  }
  public void RemoveEntry(int index)
  {
    try
    {
      entries.RemoveAt(index);
      logger.Log($"Removed line number '{index}' from the journal", LOGTYPE.TRACE);
    }
    catch (Exception ex)
    {
      logger.Log(ex.ToString(), LOGTYPE.ERROR, DateTime.Now);
    }
  }
  public override string ToString()
  {
    return string.Join(Environment.NewLine, entries);
  }
}

public class Logger
{
  private readonly string _filePath;
  public Logger(string? filePath = null) { _filePath = filePath ?? @"c:\temp\defaultlogger.txt"; }
  public void Log(string message, LOGTYPE type, DateTime? dateTime = null)
  {
    File.WriteAllTextAsync(
      _filePath,
      $"[{type.ToString()}##{dateTime ?? DateTime.Now}] {message}"
    );
  }
}

public static class Disk
{
  public static void Save(string content, string? filePath = null)
  {
    File.WriteAllTextAsync(filePath ?? @"c:\temp\default_journal.txt", content);
  }
}