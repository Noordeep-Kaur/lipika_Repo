import { Feedback } from '../models/feedback';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class FeedbackService{

    feedback;
    feedbacks: Feedback[];
    constructor(private http:HttpClient){
        this.feedbacks=[];
    }
    public addFeedback(feedback){
        console.log(feedback);
        return this.http.post("http://localhost:51455/api/Feedback",feedback);
    }
}