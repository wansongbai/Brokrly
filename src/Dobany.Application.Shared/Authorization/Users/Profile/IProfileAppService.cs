using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Dobany.Authorization.Users.Dto;
using Dobany.Authorization.Users.Profile.Dto;
using Dobany.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dobany.Authorization.Users.Profile
{
    public interface IProfileAppService : IApplicationService
    {
        Task<CurrentUserProfileEditDto> GetCurrentUserProfileForEdit();

        Task<CurrentUserProfileEditDto> GetCurrentUserProfileByUserId(long userId);

        Task UpdateCurrentUserProfile(CurrentUserProfileEditDto input);

        Task UpdateUserProfile(UserProfileEditDto input);

        Task ChangePassword(ChangePasswordInput input);

        Task UpdateProfilePicture(UpdateProfilePictureInput input);

        Task<GetPasswordComplexitySettingOutput> GetPasswordComplexitySetting();

        Task<GetProfilePictureOutput> GetProfilePicture();

        Task<GetProfilePictureOutput> GetProfilePictureByUser(long userId);
        
        Task<GetProfilePictureOutput> GetProfilePictureByUserName(string username);

        Task<GetProfilePictureOutput> GetFriendProfilePicture(GetFriendProfilePictureInput input);

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<UpdateGoogleAuthenticatorKeyOutput> UpdateGoogleAuthenticatorKey();

        Task SendVerificationSms(SendVerificationSmsInputDto input);

        Task VerifySmsCode(VerifySmsCodeInputDto input);

        Task PrepareCollectedData();

        Task<UploadProfilePictureOutput> UploadProfilePicture(IFormFile file, string fileToken, string fileType);

        Task UpdateUserProfileInfo(UserProfileInfoEditDto input);
    }
}
