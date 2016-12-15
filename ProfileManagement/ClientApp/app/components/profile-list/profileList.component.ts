import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Profile } from '../../dataModel/Profile.ts';   //Data Model

@Component({
    selector: 'profile-list',
    template: require('./profileList.component.html'),
    styles: [require('./profileList.component.css')]
})

export class ProfileListComponent
{
    public profiles: Profile[];         //Can be accessed in view
    public loadingMessage: string = "Loading Data ..";

    constructor(http: Http)
    {
        http.get('/api/Profile/Get?currentPageNo=1&pageSize=20').subscribe(result =>
        {
            this.profiles = result.json();
            console.log(result);
        });
    }

    ngOnChanges(changes)
    {
        console.log(this.profiles.length);

        if (this.profiles.length < 1) {
            this.loadingMessage = "No Data Found !!!";      //interpolation
        }
        else
        {
            this.loadingMessage = "Data Loaded..";      //interpolation
        }
    }

    public addProfile()
    {
        alert("Add new Profile");
    }
}
