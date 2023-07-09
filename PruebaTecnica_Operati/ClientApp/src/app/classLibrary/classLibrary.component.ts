import { Component, OnInit } from '@angular/core';
import { UserService } from '../_service/user.service';

@Component({
  selector: 'app-class-library',
  templateUrl: './classLibrary.component.html',
})
export class ClassLibraryComponent implements OnInit {
  public tree = "['(1,2)','(2,4)','(5,7)','(7,2)','(9,5)']";
  public node = "[b-e,b-c,c-d,a-b,e-f]";
  public resultTree = false;
  public resultNode = 0;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  onClickTree(): void {
    this.userService.treeConstructor(this.tree).subscribe(
      data => {
        console.log(data);
        this.resultTree = data;
      },
      err => {
        console.log(err);
        this.resultTree = false;
      }
    );
  }

  onClickFarthest(): void {
    this.userService.farthestNodes(this.node).subscribe(
      data => {
        console.log(data);
        this.resultNode = data;
      },
      err => {
        console.log(err);
        this.resultNode = 0;
      }
    );
  }
}
