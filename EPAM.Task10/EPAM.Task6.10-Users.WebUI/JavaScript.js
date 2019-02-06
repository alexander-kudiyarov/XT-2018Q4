let isAddUserMenuOpen = false;
let isRemoveUserMenuOpen = false;
let isAwardsMenuOpen = false;

function AddUserMenu() {
    if (!isAddUserMenuOpen) {
        Clear('removeUser');
        Clear('addAwards');

        isAddUserMenuOpen = true;
        isRemoveUserMenuOpen = false;
        isAwardsMenuOpen = false;

        let firstName = document.createElement('label');
        firstName.innerHTML = 'First Name';
        document.getElementById('addUser').appendChild(firstName);

        let firstNameInput = document.createElement('input');
        firstNameInput.type = "text";
        firstNameInput.name = "f_name";
        document.getElementById('addUser').appendChild(firstNameInput);

        let lastName = document.createElement('label');
        lastName.innerHTML = 'Last Name';
        document.getElementById('addUser').appendChild(lastName);

        let lastNameInput = document.createElement('input');
        lastNameInput.type = "text";
        lastNameInput.name = "l_name";
        document.getElementById('addUser').appendChild(lastNameInput);

        let birthDate = document.createElement('label');
        birthDate.innerHTML = 'Birth Date';
        document.getElementById('addUser').appendChild(birthDate);

        let birthDateInput = document.createElement('input');
        birthDateInput.type = "text";
        birthDateInput.name = "b_date";
        document.getElementById('addUser').appendChild(birthDateInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('addUser').appendChild(submit);
    }
}

function RemoveUserMenu() {
    if (!isRemoveUserMenuOpen) {
        Clear('addUser');
        Clear('addAwards');

        isAddUserMenuOpen = false;
        isRemoveUserMenuOpen = true;
        isAwardsMenuOpen = false;

        let id = document.createElement('label');
        id.innerHTML = 'ID to remove';
        document.getElementById('removeUser').appendChild(id);

        let idInput = document.createElement('input');
        idInput.type = "text";
        idInput.name = "id";
        document.getElementById('removeUser').appendChild(idInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('removeUser').appendChild(submit);
    }
}

function AwardsUserMenu() {
    if (!isAwardsMenuOpen) {
        Clear('addUser');
        Clear('removeUser');

        isAddUserMenuOpen = false;
        isRemoveUserMenuOpen = false;
        isAwardsMenuOpen = true;

        let title = document.createElement('label');
        title.innerHTML = 'Title';
        document.getElementById('addAwards').appendChild(title);

        let titleInput = document.createElement('input');
        titleInput.type = "text";
        titleInput.name = "title";
        document.getElementById('addAwards').appendChild(titleInput);

        let users = document.createElement('label');
        users.innerHTML = 'ID of users to awards';
        document.getElementById('addAwards').appendChild(users);

        let usersInput = document.createElement('input');
        usersInput.type = "text";
        usersInput.name = "users";
        document.getElementById('addAwards').appendChild(usersInput);

        let submit = document.createElement('button');
        submit.innerHTML = 'Submit';
        submit.type = "submit";
        document.getElementById('addAwards').appendChild(submit);
    }
}

function Clear(form) {
    let myNode = document.getElementById(form);
    while (myNode.firstChild) {
        myNode.removeChild(myNode.firstChild);
    }
}