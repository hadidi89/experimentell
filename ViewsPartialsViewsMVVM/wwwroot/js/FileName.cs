@*@model RegisterAccountViewModel

< section class= "register-form" >
    < div class= "container" >
        < div class= "form-content" >
            < div class= "form-title" > Please Register Your new Account</div>
            < hr >
            < form id = "registerForm" method = "post" novalidate >

                < div class= "line" >
                    < div asp - validation - summary = "ModelOnly" class= "error-text" ></ div >
                </ div >

                < div class= "line grid" >
                    < div class= "column" >
                        < label for= "FirstName" > First Name:</ label >
                        < input id = "FirstName" name = "FirstName" type = "text" required />
                        < span asp - validation -for= "FirstName" class= "error-text" ></ span >
                        < span id = "RegisterFirstNameError" class= "error-text" ></ span >
                    </ div >

                    < div class= "column" >
                        < label for= "LastName" > Last Name:</ label >
                        < input id = "LastName" name = "LastName" type = "text" required />
                        < span asp - validation -for= "LastName" class= "error-text" ></ span >
                        < span id = "RegisterLastNameError" class= "error-text" ></ span >
                    </ div >
                </ div >

                < div class= "line" >
                    < label for= "StreetName" > Street Name:</ label >
                    < input id = "StreetName" name = "StreetName" type = "text" required />
                </ div >

                < div class= "line grid" >
                    < div class= "column" >
                        < label for= "PostalCode" > Postal Code:</ label >
                        < input id = "PostalCode" name = "PostalCode" type = "text" required />
                    </ div >
                    < div class= "column" >
                        < label for= "City" > City:</ label >
                        < input id = "City" name = "City" type = "text" required />
                    </ div >
                </ div >

                < div class= "line grid" >
                    < div class= "column" >
                        < label for= "PhoneNumber" > Phone Number:</ label >
                        < input id = "PhoneNumber" name = "PhoneNumber" type = "tel" />
                    </ div >
                    < div class= "column" >
                        < label for= "CompanyName" > Company Name:</ label >
                        < input id = "CompanyName" name = "CompanyName" type = "text" />
                    </ div >
                </ div >

                < div class= "line" >
                    < label for= "Email" > Email:</ label >
                    < input id = "Email" name = "Email" type = "email" required />
                    < span asp - validation -for= "Email" class= "error-text" ></ span >
                    < span id = "RegisterEmailError" class= "error-text" ></ span >
                </ div >

                < div class= "line" >
                    < label for= "Password" > Password:</ label >
                    < input id = "Password" name = "Password" type = "password" autocomplete = "new-password" required >
                    < span asp - validation -for= "Password" class= "error-text" ></ span >
                    < span id = "RegisterPasswordError" class= "error-text" ></ span >
                </ div >

                < div class= "line" >
                    < label for= "ConfirmPassword" > Confirm Password:</ label >
                    < input id = "ConfirmPassword" name = "ConfirmPassword" type = "password" required />
                    < span asp - validation -for= "ConfirmPassword" class= "error-text" ></ span >
                </ div >

                < div class= "line" >
                    < label for= "ProfileImage" > Profile Image:</ label >
                    < input id = "ProfileImage" name = "ProfileImage" type = "file" accept = "image/*" />
                </ div >

                < div class= "terms form-checkbox-group" >
                    < label class= "custom-checkbox" >
                        I have read and accept the terms and agreements
                        <input id="AcceptsTerms" name="AcceptsTerms" type="checkbox" checked="checked">
                        <span class= "checkmark" ></ span >
                        < span asp - validation -for= "AcceptsTerms" class= "error-text" ></ span >
                    </ label >
                </ div >

                < button class= "btn-theme" type = "submit" > Submit </ button >
            </ form >
        </ div >
    </ div >
</ section > *@