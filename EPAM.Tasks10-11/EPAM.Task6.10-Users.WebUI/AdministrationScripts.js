let isEditProgramUserMenuOpen = false;
let isRemoveProgramUserMenuOpen = false;
let allMenu = ["editProgramUserMenu", "removeProgramUserMenu"];

function EditProgramUserMenu() {
    if (!isEditProgramUserMenuOpen) {
        ClearAll();
        ResetAllBool();
        isEditUserMenuOpen = true;

        let usernameInput = document.createElement('input');
        usernameInput.placeholder = "Username";
        usernameInput.type = "text";
        usernameInput.name = "usernameToEdit";
        document.getElementById('editProgramUserMenu').appendChild(usernameInput);

        let newRoleInput = document.createElement('input');
        newRoleInput.placeholder = "New Role";
        newRoleInput.type = "text";
        newRoleInput.name = "newRole";
        document.getElementById('editProgramUserMenu').appendChild(newRoleInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('editProgramUserMenu').appendChild(submit);
    }
}

function RemoveProgramUserMenu() {
    if (!isRemoveProgramUserMenuOpen) {
        ClearAll();
        ResetAllBool();
        isRemoveUserMenuOpen = true;

        let usernameInput = document.createElement('input');
        usernameInput.placeholder = "Username";
        usernameInput.type = "text";
        usernameInput.name = "usernameToRemove";
        document.getElementById('removeProgramUserMenu').appendChild(usernameInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('removeProgramUserMenu').appendChild(submit);
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
    isEditProgramUserMenuOpen = false;
    isRemoveProgramUserMenuOpen = false;
}