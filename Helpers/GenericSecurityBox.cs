namespace FirstLanguageSampleMexico.Helpers;

// Generic -> blueprint to create classes
public class GenericSecurityBox<T, K>
{
    T _data;
    K _password;

    public GenericSecurityBox(T data, K password)
    {
        _data = data;
        _password = password;
    }

    public T GetData(string password)
    {
        if (password.Equals(_password))
        {
            return _data;
        }

        throw new Exception();
    }

}
