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

    public editProfile(profileId)
    {
        alert("Edited - " + profileId);
    }

    public deleteProfile(profileId)
    {
        //http://localhost:63032/api/Profile/Delete
        //profileID
        /*
        this.http.delete(`/api/Profile/Delete`) // ...using put request
            .map((res: Response) => res.json()) // ...and calling .json() on the response to return data
            .catch((error: any) => Observable.throw(error.json().error || 'Server error')); //...errors if
        */
        alert("Deleted - " + profileId);
    }
}
