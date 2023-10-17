﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP_JMS.Model.Api.Response
{
    public class UserCommonDisplayModel
    {
        public Guid UserId { get; set; }

        public string Username { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public string Fullname { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
