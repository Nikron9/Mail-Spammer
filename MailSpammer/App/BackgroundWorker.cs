﻿
namespace App
{
    public class BackgroundWorker : IBackgroundWorker
    {
        private readonly ISpamService _spammer;
        public BackgroundWorker(ISpamService spammer)
        {
            _spammer = spammer;
        }

        public void DoWork()
        {
            _spammer.SendMails();
        }
    }
}