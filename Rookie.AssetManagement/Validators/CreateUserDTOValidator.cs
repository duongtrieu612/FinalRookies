using System;
using FluentValidation;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;


public class CreateUserDTOValidator : AbstractValidator<UserCreateDto> {
    public CreateUserDTOValidator(){
        
        RuleFor(user=>user.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("First Name is empty")
            .Matches(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀẾỄỂưăạảấầẩẫậắằẳẵặẹẻẽềếểễệỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹa-zA-Z
            ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s_ ]+$")
            .WithMessage("Name cannot contain number or special charater");

        RuleFor(user=>user.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Last Name is empty")
            .Matches(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀẾỄỂưăạảấầẩẫậắằẳẵặẹẻẽềếểễệỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹa-zA-Z
            ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\s_ ]+$")
            .WithMessage("Name cannot contain number or special charater");

        RuleFor(user=>user.DateOfBirth)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Please Select Date of Birth")
            .LessThan(DateTime.Now.AddYears(-18))
            .WithMessage("User is under 18, please select different date");

        RuleFor(user=>user.JoinedDate)
            .Cascade(CascadeMode.Stop)
            .LessThanOrEqualTo(DateTime.Now)
            .GreaterThanOrEqualTo(user=>user.DateOfBirth
            .AddYears(+18))
            .WithMessage("User under the age of 18 may not join company. Please select a different date");
        
        RuleFor(user=>user.JoinedDate.DayOfWeek)
            .NotEqual(DayOfWeek.Saturday)
            .WithMessage("Joined date is Saturday or Sunday. Please select a different date")
            .NotEqual( DayOfWeek.Sunday)
            .WithMessage("Joined date is Saturday or Sunday. Please select a different date");
        
        RuleFor(user=>user.Type).NotEmpty().WithMessage("Type is empty");
    }   

}