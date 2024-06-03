namespace UserService.Models.Dto
{
    public static class Auth
    {
        
        // Visit plans
        public const string ViewAllVisitPlans = "View All Visit Plans";
        public const string CreateNewVisitPlan = "Create New Visit Plan";
        public const string ViewAllExistingTasks = "View All Existing Tasks";

        // Notification
        public const string CreateNotification = "Create Notification";

        // Survey
        public const string CreateNewSurvey = "Create New Survey";
        public const string SendSurveyRequest = "Send Survey Request";

        // CMS
        public const string CreateNewArticle = "Create New Article";
        public const string UpdateArticleDetail = "Update Article Detail";
        public const string PublishExistingArticle = "Publish Existing Article";
        public const string RemoveUnpublishArticles = "Remove Unpublish Articles";

        // Users
        public const string AddNewUsers = "Add New Users";
        public const string UpdateUserDetail = "Update User Detail";
        public const string ResetPassword = "Reset Password";
        public const string PermissionSetting = "Permission Setting";

        // Areas
        public const string CreateNewArea = "Create New Area";
        public const string UpdateAreaDetail = "Update Area Detail";
        public const string DeleteAreas = "Delete Areas";

        // Distributors
        public const string CreateNewDistributor = "Create New Distributor";
        public const string UpdateDistributorDetail = "Update Detail Distributor";
        public const string DeleteDistributor = "Delete Distributor";

        // System configuration
        public const string EditSystemConfiguration = "Edit System Configuration";
    }

    public static class AuthGroup
    {
        public const string VisitPlans = "Visit plans";
        public const string Notification = "Notification";
        public const string Survey = " Survey";
        public const string CMS = "CMS";
        public const string Users = "Users";
        public const string Areas = "Areas";
        public const string Distributors = "Distributors";
        public const string SystemConfiguration = "System configuration";
    }
}
