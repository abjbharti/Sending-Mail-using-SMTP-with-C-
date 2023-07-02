using System.Text.RegularExpressions;

public class Validation
{

    public bool isValidName(string inputName)
    {
        string strRegex = @"^[a-zA-Z]+$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputName))
            return (true);
        else
            return (false);
    }

    public bool isValidEmail(string inputEmail)
    {
        string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }
}