using Microsoft.Extensions.Configuration;

namespace fgk.Infrastructure.Options
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public int HoursBeforeExpire { get; set; }

        public JwtOptions(IConfiguration configuration)
        {
            Key = configuration["JwtOptions:Key"]!;
            HoursBeforeExpire = Convert.ToInt32(configuration["JwtOptions:HoursBeforeExprire"]!);
        }
    };
}
