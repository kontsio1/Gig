kontsio IAM
access key: AKIAQSOI4CSW4FCAI4ZH
secret access key: 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

to deploy to beanstalk:
dotnet publish -c Release -o publish
cd publish
eb deploy (in command prompt - probably preceeded by eb)
