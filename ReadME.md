QnAApp
│
├── QnAApp.API
│   ├── Controllers
│   │   ├── QuestionController.cs
│   │   ├── AnswerController.cs
│   │   └── CommentController.cs
│   │
│   ├── Views
│   │   ├── Question
│   │   │   ├── Index.cshtml
│   │   │   ├── Create.cshtml
│   │   │   ├── Edit.cshtml
│   │   │
│   │   ├── Answer
│   │   │   └── _AnswerPartial.cshtml
│   │   │
│   │   ├── Comment
│   │   │   └── _CommentPartial.cshtml
│   │   │
│   │   └── Shared
│   │       └── _Layout.cshtml
│   │
│   ├── ViewModels
│   │   ├── QuestionVM.cs
│   │   ├── AnswerVM.cs
│   │   └── CommentVM.cs
│   │
│   ├── Extensions
│   │   └── ServiceExtensions.cs
│   │
│   ├── Program.cs
│   └── appsettings.json
│
├── QnAApp.Application
│   ├── Interfaces
│   │   ├── IQuestionRepository.cs
│   │   ├── IAnswerRepository.cs
│   │   └── ICommentRepository.cs
│   │
│   └── Services
│       ├── QuestionService.cs
│       ├── AnswerService.cs
│       └── CommentService.cs
│
├── QnAApp.Domain
│   └── Entities
│       ├── Question.cs
│       ├── Answer.cs
│       └── Comment.cs
│
└── QnAApp.Infrastructure
    ├── Data
    │   └── AppDbContext.cs
    │
    ├── Repositories
    │   ├── QuestionRepository.cs
    │   ├── AnswerRepository.cs
    │   └── CommentRepository.cs
    │
    └── Migrations
