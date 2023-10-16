﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEP_JMS.Common.Constants;
using SEP_JMS.Common;
using SEP_JMS.Model.Api.Request.Comment;
using SEP_JMS.Model.Enums.System;
using SEP_JMS.Service.Services;
using SEP_JMS.Service.IServices;
using SEP_JMS.Common.Logger;

namespace SEP_JMS.API.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly string logPrefix = "[CommentController]";
        private readonly ICommentService commentService;
        private readonly IJMSLogger logger;

        public CommentController(ICommentService commentService,
            IJMSLogger logger)
        {
            this.commentService = commentService;
            this.logger = logger;
        }
        [Authorize]
        [RequestSizeLimit(PolicyConstants.commentFileSize)]
        [RequestFormLimits(MultipartBodyLengthLimit = PolicyConstants.commentFileSize)]
        [HttpPost("{jobId}")]
        public async Task<IActionResult> CreateComment([FromRoute] Guid jobId, [FromForm] CommentCreateRequestModel model)
        {
            try
            {
                logger.Info($"{logPrefix} Start to post comment for the job {jobId}.");
                if (ApiContext.Current.Role == RoleType.Customer && model.VisibleType == VisibleType.Internal) return StatusCode(403);
                var success = await commentService.CreateComment(jobId, model);
                return success ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.Error($"{logPrefix} Got exception when posting a comment for the job {jobId}. Error: {ex}");
                return StatusCode(500);
            }
        }
    }
}
