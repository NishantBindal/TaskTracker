﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.DAL.Migrations
{
    public partial class AddClientConfig : Migration
    {
        protected string JIRA_BASE_URL = "https://sprintplanner.atlassian.net/";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO AUTHCLIENTCONFIGS VALUES('https://sprintplanner.atlassian.net/','-----BEGIN RSA PRIVATE KEY-----
MIICXQIBAAKBgQDV3irA4Jk7oGXtKyLMqBNE0S18RrKm7B4TOR1dAlRkifa7JSMz
Dp0CtnwgoUWvEupWaZQfwqKlVoylFZUQzv5GvRH6PFDCgCV95/zu7AqWrQFC3xX0
donP3AOwhuJyKb5Z4O5oSYPMG93Sani/7qxrmyw8/YGhOA7mbOfh3di3CQIDAQAB
AoGBAMKkxohwYUWxP9LQlYVp2s+hCSK4PVRKRTz9mEnUGva90b6VmCmZvTCA4QvZ
e1BRiNFImbUmMV0FHlAJCngXy7bvsvljDQ7hv6qIUanN+fKjbjgen7C5dyUC8GmG
eF6/k2lzQXPx4TTgZTI0YdqNKX4zWR1yMgh4GHEKGiuBMWTZAkEA8UlCodRBmiCw
kHl9YfPjxTrjTNCd/L8zBwNWvcaUsuDhg3vSOWJ5gajHxhJOtJC5trmcx60lJT7Q
FN8U4wkBZwJBAOLo4G/1m0g+LR0FeRytp3CZjuzxuVu0hiTrshgBMH9UBxaF3FNj
qApZFUeQbl05nOAMD5/r8Rtd/iSwO58SDg8CQQDYDFsngGFFWuP+WWpVnQZkAfip
PVtZhvJv4yN2Riu7h/UlwGdajrxxxukqiBYFRFmmLckeWgEauoWjSqTvLY8dAkBF
cZHmkdshI+44mIk1TqwU2NoWB/B7cWcwe3W4xPxrq3Kz4OnKF5DBAfxyN3CfVVd+
dhJ+Ff5nKr/xyIGmsCbfAkBm2Fxqtc3MbT/rBK9K1XQNxjwVtJgGXJPZUWAeBaZE
9yG01c0tTSYiwaMH65k6jfba/p7vgfE6wkNItUkaQBDY
-----END RSA PRIVATE KEY-----
')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Delete from AuthClientConfigs where baseuri='https://sprintplanner.atlassian.net/'");
        }
    }
}
