using System;
using Trello.Domain.Entities;

namespace Trello.Service.Models.Labels.Request
{
    public class LabelCreateRequest
    {
        public Workspace Workspace { get; set; }
        public string Color { get; set; }

        public LabelCreateRequest(Workspace workspace, string color)
        {
            Workspace = workspace;
            Color = color;
        }
        public Label ConvertToEntity()
        {
            return new Label
            {
                Workspace = Workspace,
                Color = Color,
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}
