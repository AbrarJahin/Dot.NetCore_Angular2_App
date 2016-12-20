'use strict';

import { Component, NgModule } from '@angular/core';
import { Http, RequestOptions, URLSearchParams } from '@angular/http';
import { Profile } from '../../dataModel/Profile.ts';   //Data Model
import { Router } from '@angular/router';

@Component({
    selector: 'profile-list',
    template: require('./profileList.component.html'),
    styles: [require('./profileList.component.css')]
})

export class ProfileListComponent
{
    private profiles: Profile[];         //All Profiles
    private loadingMessage: string = "Loading Data ..";

    private _getAllProfileUrl: string = "/api/Profile/Get?currentPageNo=1&pageSize=200";
    private _deleteProfileUrl: string = "/api/Profile/Delete";

    private isModalVisible = false;
    private isModalAnimatable = false;

    constructor(private http: Http, private router: Router){}

    ngOnInit(): void
    {
        this.reloadAllData();
    }

    ngOnChanges(changes): void
    {
        console.log(this.profiles.length);

        if (this.profiles.length < 1)
        {
            this.loadingMessage = "No Data Found !!!";      //interpolation
        }
        else
        {
            this.loadingMessage = "Data Loaded..";      //interpolation
        }
    }

    public viewProfile(profileId): void
    {
        alert("View - " + profileId);
    }

    public addProfileSubmit(event,name,dob): void
    {
        event.preventDefault();
        alert("Profile Added Successfully");
        //this.router.navigate(['./SomewhereElse']);

        console.log(name);
        console.log(dob);

        this.reloadAllData();
        this.hideAddProfileModal();
    }

    public editProfile(profileId): void
    {
        alert("Edited - " + profileId);
    }

    public deleteProfile(profileId): void
    {
        this.http.delete(this._deleteProfileUrl, new RequestOptions({
            search: new URLSearchParams('profileId=' + profileId)
        })).subscribe(res => {
            alert("Deleted - " + profileId);
            this.reloadAllData();
        });
    }

    private reloadAllData(): void
    {
        this.http.get(this._getAllProfileUrl)
            .subscribe(result => {
                this.profiles = result.json();
                console.log(result);
            });
    }

    public showAddProfileModal(): void
    {
        this.isModalVisible = true;
        setTimeout(() => this.isModalAnimatable = true, 300);
    }

    public hideAddProfileModal(): void
    {
        this.isModalAnimatable = false;
        setTimeout(() => this.isModalVisible = false, 300);
    }
}
