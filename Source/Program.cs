using System;
using System.Collections.Generic;
using Source.Assignments.LeetcodePracticeDifficultyMedium;
using System.Security.Cryptography.X509Certificates;

public class Program
{
   public static Dictionary<string, Action> callbacks = new Dictionary<string, Action>();
    private static void InitalizeCallbacks()
    {
        callbacks["ltpcm"] = () => Submission_ITPCM.Main(new string[0]);
    }

    /// <summary>
    /// Provided for quality of life. Will be updated to the key of the most recent submission. 
    /// </summary>
    /// <returns></returns>
    private static string GetCurrent() => "ltpcm";

    public static void Main(string[] args)
    {
        args = (args.Count() is 0) ? new string[1] { GetCurrent() } : args;
        string submissionID = args[0].ToLower().Trim();


        InitalizeCallbacks(); 

        if (callbacks.ContainsKey(submissionID))
        {
            Console.WriteLine($"Executing command for submission {submissionID}");
            callbacks[submissionID]();
        }
        else
        {
            throw new ArgumentException($"Expected command ID was not reconized. Got {submissionID}");
        }
    }
}