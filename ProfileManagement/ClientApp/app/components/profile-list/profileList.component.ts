import { Component } from '@angular/core';
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import { Profile } from '../../dataModel/Profile.ts';   //Data Model
//import { Router } from '@angular/router';

@Component({
    selector: 'profile-list',
    template: require('./profileList.component.html'),
    styles: [require('./profileList.component.css')]
})

export class ProfileListComponent
{
    public profiles: Profile[];         //Can be accessed in view
    public loadingMessage: string = "Loading Data ..";

    private _getAllProfileUrl: string = "/api/Profile/Get?currentPageNo=1&pageSize=200";
    private _deleteProfileUrl: string = "/api/Profile/Delete";

    constructor(private http: Http) { }   //, private router: Router

    ngOnInit(): void
    {
        this.reloadAllData();
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

    public viewProfile(profileId)
    {
        alert("View - " + profileId);
    }

    /*
    public addProfile()
    {
        alert("Add new Profile");
        this.router.navigate(['./SomewhereElse']);
    }
    */

    public editProfile(profileId)
    {
        alert("Edited - " + profileId);
    }

    public deleteProfile(profileId)
    {
        this.http.delete(this._deleteProfileUrl, new RequestOptions({
            search: new URLSearchParams('profileId=' + profileId)
        })).subscribe(res => {
            alert("Deleted - " + profileId);
            this.reloadAllData();
        });
    }

    private reloadAllData()
    {
        this.http.get(this._getAllProfileUrl)
            .subscribe(result => {
                this.profiles = result.json();
                console.log(result);
            });
    }
}
