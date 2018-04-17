﻿using Command.Abstracts;
using System;
using System.Collections.Generic;

namespace Command
{
    public abstract class CommandBase
    {
        protected virtual IRequirements Requirements { get; }
        protected CommandBase(IRequirements requirements)
        {
            Requirements = requirements;
        }
        protected string GetRandomAnswer()
        {
            var r=new Random();
            var index= r.Next(Answers.Count);
            return Answers[index];
        }
        public abstract List<string> Keys { get; }
        public abstract List<string> Answers { get; }
        public abstract string Topic { get; }
        public abstract string OwnerPlugin { get; }
        public virtual void DoJob()
        {
            Brain.PreviousCommand = this;
            Requirements.TextToSpeech.Speak(GetRandomAnswer());
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(string)) return false;

            foreach (var key in this.Keys)
            {
                if (key.ToLower() == obj.ToString().ToLower()) return true;
            }

            return false;
        }
    }
}