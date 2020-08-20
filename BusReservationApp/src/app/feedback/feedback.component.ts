import { Component, OnInit } from '@angular/core';
import { Feedback } from '../models/feedback';
import { FeedbackService } from '../Services/feedbackservice';
import { FormsModule, FormGroup, Validators, FormControl} from '@angular/forms';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  feedbacks;
  result;
  feedback: Feedback;
  
  myFeedbackForm:FormGroup;
  welcome:boolean;

  constructor(private feedbackService: FeedbackService) {
    this.feedback = new Feedback();
    this.feedbacks = [];

    this.myFeedbackForm = new FormGroup({
      pnr: new FormControl(null,Validators.required),
      rating: new FormControl(null,Validators.required),
      comment: new FormControl(null,Validators.required)
    });
    this.welcome=false;
   }
   public get pnr(){
     return this.myFeedbackForm.get("pnr");
  }
   public get rating(){
     return this.myFeedbackForm.get("rating");
   }
   public get comment(){
    return this.myFeedbackForm.get("comment");
  }

   get f(){
    return this.myFeedbackForm.controls;
  }

  changeRating(e) {
    console.log(e.target.value);
  }

  Submit(){
  this.feedbackService.addFeedback(this.feedback).subscribe((data) => {
    this.result = data;
   })
  }

  ngOnInit(): void {
  }

}
