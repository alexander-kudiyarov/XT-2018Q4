let isAddUserMenuOpen = false;
let isEditUserMenuOpen = false;
let isRemoveUserMenuOpen = false;
let isAddAwardsMenuOpen = false;
let isRemoveAwardsMenuOpen = false;


let allMenu = ["addUserMenu", "editUserMenu", "removeUserMenu", "addAwardsMenu", "removeAwardsMenu"];

function AddUserMenu() {
    if (!isAddUserMenuOpen) {
        ClearAll();
        ResetAllBool();

        isAddUserMenuOpen = true;

        let firstNameInput = document.createElement('input');
        firstNameInput.placeholder = 'First Name';
        firstNameInput.type = "text";
        firstNameInput.name = "addFirstName";
        document.getElementById('addUserMenu').appendChild(firstNameInput);

        let lastNameInput = document.createElement('input');
        lastNameInput.placeholder = "Last Name (optional)";
        lastNameInput.type = "text";
        lastNameInput.name = "addLastName";
        document.getElementById('addUserMenu').appendChild(lastNameInput);

        let birthDateInput = document.createElement('input');
        birthDateInput.placeholder = "Birth Date";
        birthDateInput.type = "text";
        birthDateInput.setAttribute('onfocus', '(this.type="date")');
        birthDateInput.setAttribute('onfocusout', '(this.type="text")');
        birthDateInput.name = "addBirthDate";
        document.getElementById('addUserMenu').appendChild(birthDateInput);

        let userImageInput = document.createElement('input');
        userImageInput.placeholder = "Image";
        userImageInput.type = "url";
        birthDateInput.setAttribute('onfocusout', '(this.type="text")');
        userImageInput.name = "addUserImage";
        document.getElementById('addUserMenu').appendChild(userImageInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('addUserMenu').appendChild(submit);
    }
}

function EditUserMenu() {
    if (!isEditUserMenuOpen) {
        ClearAll();
        ResetAllBool();

        isEditUserMenuOpen = true;

        let idInput = document.createElement('input');
        idInput.placeholder = "ID to edit";
        idInput.type = "number";
        idInput.setAttribute('min', '1');
        idInput.name = "editId";
        document.getElementById('editUserMenu').appendChild(idInput);

        let firstNameInput = document.createElement('input');
        firstNameInput.placeholder = "First Name (optional)";
        firstNameInput.type = "text";
        firstNameInput.name = "editFirstName";
        document.getElementById('editUserMenu').appendChild(firstNameInput);

        let lastNameInput = document.createElement('input');
        lastNameInput.placeholder = "Last Name (optional)";
        lastNameInput.type = "text";
        lastNameInput.name = "editLastName";
        document.getElementById('editUserMenu').appendChild(lastNameInput);

        let birthDateInput = document.createElement('input');
        birthDateInput.placeholder = "Birth Date (optional)";
        birthDateInput.type = "text";
        birthDateInput.setAttribute('onfocus', '(this.type="date")');
        birthDateInput.setAttribute('onfocusout', '(this.type="text")');
        birthDateInput.name = "editBirthDate";
        document.getElementById('editUserMenu').appendChild(birthDateInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('editUserMenu').appendChild(submit);
    }
}

function RemoveUserMenu() {
    if (!isRemoveUserMenuOpen) {
        ClearAll();
        ResetAllBool();

        isRemoveUserMenuOpen = true;

        let idInput = document.createElement('input');
        idInput.placeholder = "ID\'s to remove";
        idInput.type = "text";
        idInput.name = "removeId";
        document.getElementById('removeUserMenu').appendChild(idInput);

        let submit = document.createElement('button');
        submit.id = "remove";
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('removeUserMenu').appendChild(submit);
    }
}

function AddAwardMenu() {
    if (!isAddAwardsMenuOpen) {
        ClearAll();
        ResetAllBool();

        isAddAwardsMenuOpen = true;

        let titleInput = document.createElement('input');
        titleInput.placeholder = "Award Title";
        titleInput.type = "text";
        titleInput.name = "addAwardTitle";
        document.getElementById('addAwardsMenu').appendChild(titleInput);

        let usersInput = document.createElement('input');
        usersInput.placeholder = "ID\'s to award";
        usersInput.type = "text";
        usersInput.name = "addAwardId";
        document.getElementById('addAwardsMenu').appendChild(usersInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('addAwardsMenu').appendChild(submit);
    }
}

function RemoveAwardMenu() {
    if (!isRemoveAwardsMenuOpen) {
        ClearAll();
        ResetAllBool();

        isRemoveAwardsMenuOpen = true;

        let titleInput = document.createElement('input');
        titleInput.placeholder = "Award Title to remove";
        titleInput.type = "text";
        titleInput.name = "removeAwardTitle";
        document.getElementById('removeAwardsMenu').appendChild(titleInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        submit.id = "remove";
        document.getElementById('removeAwardsMenu').appendChild(submit);
    }
}

function Clear(form) {
    let myNode = document.getElementById(form);
    while (myNode.firstChild) {
        myNode.removeChild(myNode.firstChild);
    }
}

function ClearAll() {
    allMenu.forEach((element) => {
        Clear(element);
    })
}

function ResetAllBool() {
    isAddUserMenuOpen = false;
    isEditUserMenuOpen = false;
    isRemoveUserMenuOpen = false;
    isAddAwardsMenuOpen = false;
    isRemoveAwardsMenuOpen = false;
}