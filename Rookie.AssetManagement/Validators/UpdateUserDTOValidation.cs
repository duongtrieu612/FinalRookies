using System;
using FluentValidation;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;


public class UpdateUserDTOValidator : AbstractValidator<UserUpdateDto> {
    public UpdateUserDTOValidator(){
        
        RuleFor(user=>user.FirstName)
            .NotEmpty()
            .WithMessage("First Name is empty")
            .Matches(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s_ ]+$")
            .WithMessage("Name cannot contain number or special charater");

           
        RuleFor(user=>user.LastName)
            .NotEmpty()
            .WithMessage("Last Name is empty")
            .Matches(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s_ ]+$")
            .WithMessage("Name cannot contain number or special charater");


        RuleFor(user=>user.DateOfBirth)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .LessThan(DateTime.Now.AddYears(-18))
            .WithMessage("User is under 18, please select different date");

        RuleFor(user=>user.JoinedDate)
            .Cascade(CascadeMode.Stop)
            .LessThanOrEqualTo(DateTime.Now)
            .GreaterThanOrEqualTo(user=>user.DateOfBirth.AddYears(+18))
            .WithMessage("User under the age of 18 may not join company. Please select a different date");
        
        RuleFor(user=>user.JoinedDate.DayOfWeek)
            .NotEqual(DayOfWeek.Saturday)
            .WithMessage("Joined day is saturday, please select a different date")
            .NotEqual( DayOfWeek.Sunday)
            .WithMessage("Joined day is sunday, please select a different date");
        
    }   

}