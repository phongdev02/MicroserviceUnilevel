﻿namespace unilevel.Web.Service.IService
{
    public interface ITokenProvider
    {
        void setToken(string token);
        string? getToken();
        void clearToken();
    }
}
