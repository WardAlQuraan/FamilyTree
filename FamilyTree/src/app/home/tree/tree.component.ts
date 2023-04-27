import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Tree } from 'src/app/Models/Tree/Tree';
import { TreeService } from 'src/app/Services/Tree/tree.service';

@Component({
  selector: 'app-tree',
  templateUrl: './tree.component.html',
  styleUrls: ['./tree.component.css']
})
export class TreeComponent implements OnInit {

  tree:Tree;
  constructor(private treeService:TreeService,private route:ActivatedRoute ) {

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      var id = params.get('id');
      this.treeService.GetFirstFamily(Number(id)).subscribe(
        data=>{
          this.tree = data;
          console.log(this.tree.parent);
        }
      )
    });

  }

}
