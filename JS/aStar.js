var grid = [[1,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
            [1,1,0,1,1,1,0,1,0,1,1,1,1,1,0],
            [0,1,1,1,1,0,0,1,0,1,1,1,0,1,0],
            [0,1,0,0,0,0,0,1,0,1,1,1,0,1,0],
            [0,1,0,1,0,0,1,1,0,1,1,1,0,1,0],
            [0,1,0,1,1,0,1,1,0,1,1,1,0,1,0],
            [0,1,0,1,1,1,1,1,0,1,1,1,0,1,0],
            [0,1,0,1,0,0,1,0,0,1,0,0,0,1,0],
            [0,1,0,1,0,0,1,0,0,1,0,0,0,1,0],
            [0,1,0,1,0,0,1,0,0,1,0,1,1,1,0],
            [0,1,0,1,1,1,1,0,0,1,0,1,1,1,0],
            [0,1,1,1,1,0,1,1,1,1,1,1,1,0,0],
            [0,0,0,0,0,0,0,1,1,1,0,1,1,1,1]];
function aStar(start,end){
      var destination = new node(end[0], end[1], -1, -1, -1, -1);
      var startNode = new node(start[0], start[1], -1, -1, -1, -1);
      this.isThisInTheGrid=function(x,y){
            if(x in grid){
                  if(y in grid[x]){
                        return true;
                  }
            }
            return false;
      }
      this.getParrentFromClosed = function(child,closed){
        for(var i = 0;i<closed.length;i++){
          if(child.parent_index[0] == closed[i].x && child.parent_index[1] == closed[i].y){
            return closed[i];
          }
        }
      }
      this.generatePath = function(currnode,closed){
        var shortestPath = Array();
        while(Array.isArray(currnode.parent_index)){
          shortestPath.push(currnode);
          currnode = this.getParrentFromClosed(currnode,closed);
        }
        return shortestPath;
      }
      this.search=function(board){
           var open = []; 
           var closed = []; 
           var path = [];
           var g = 0; 
           var h = heuristic(startNode,destination); 
           var f = g+h; 
           open.push(startNode);

           while(open.length>0){
                  var best_cost = open[0].f;
                  var best_node = 0;

                  for (var i = 1; i < open.length; i++){

                        if (open[i].f < best_cost){
                              best_cost = open[i].f;
                              best_node = i;
                        }
                  }
                  var current_node = open[best_node];
                  if (current_node.x == destination.x && current_node.y == destination.y){
                      path= this.generatePath(current_node,closed);
                      return path.reverse();
                  }               
                  open.splice(best_node, 1);

                  closed.push(current_node);
                  var kids = this.getChildrens(current_node,open,closed,board);

                  open=open.concat(kids);
            }
            return [];
      }
      this.checkAkid = function(childnode,open,closed){
            for (var j in closed){
                  if (closed[j].x == childnode.x && closed[j].y == childnode.y){
                        return false;
                  }
            }
            for (var i in open){
                  if (open[i].x == childnode.x && open[i].y == childnode.y){
                        return false;
                  }
            }
            return true;
      }
      this.getChildrens=function(parrentNode,open,closed,grid){
            var childArray = Array();
            if(this.isThisInTheGrid(parrentNode.x,parrentNode.y)){
                if(this.isThisInTheGrid(parrentNode.x+1,parrentNode.y) && grid[parrentNode.x+1][parrentNode.y]!=0){
                  var child = new node(parrentNode.x+1,parrentNode.y,[parrentNode.x,parrentNode.y],parrentNode.g+1,-1,-1);
                  child.h=heuristic(child,destination);
                  child.f=child.g+child.h;
                  if(this.checkAkid(child,open,closed)){
                        childArray.push(child);
                  }
                }
                if(this.isThisInTheGrid(parrentNode.x-1,parrentNode.y) && grid[parrentNode.x-1][parrentNode.y]!=0){
                  var child = new node(parrentNode.x-1,parrentNode.y,[parrentNode.x,parrentNode.y],parrentNode.g+1,-1,-1);
                  child.h=heuristic(child,destination);
                  child.f=child.g+child.h;
                  if(this.checkAkid(child,open,closed)){
                        childArray.push(child);
                  }
                }
                if(this.isThisInTheGrid(parrentNode.x,parrentNode.y+1) && grid[parrentNode.x][parrentNode.y+1]!=0){
                  var child = new node(parrentNode.x,parrentNode.y+1,[parrentNode.x,parrentNode.y],parrentNode.g+1,-1,-1);
                  child.h=heuristic(child,destination);
                  child.f=child.g+child.h;
                  if(this.checkAkid(child,open,closed)){
                        childArray.push(child);
                  }
                }
                if(this.isThisInTheGrid(parrentNode.x,parrentNode.y-1) && grid[parrentNode.x][parrentNode.y-1]!=0){
                  var child = new node(parrentNode.x,parrentNode.y-1,[parrentNode.x,parrentNode.y],parrentNode.g+1,-1,-1);
                  child.h=heuristic(child,destination);
                  child.f=child.g+child.h;
                  if(this.checkAkid(child,open,closed)){
                        childArray.push(child);
                  }
                }
            }
            return childArray;
      }
      this.giveMeTheBestChildren=function(goodChilds){
            var bestHeuristic = goodChilds[0].f;
            var bestIndex = 0;
            for(var i=0;i<goodChilds.length;i++){
                  if(goodChilds[i].f<bestHeuristic){
                        bestHeuristic=goodChilds[i].f;
                        bestIndex=i;
                  }
            }
            return goodChilds[bestIndex];
            
      }
}
function heuristic(current_node, end){
            var x = current_node.x-end.x;
            var y = current_node.y-end.y;
            return x*x+y*y;

}
function node(x, y, parent_index, g, h, f){
    this.x = x;
    this.y = y;
    this.parent_index = parent_index;
    this.g = g;
    this.h = h;
    this.f = f;
}
var newSearch = new aStar([0,0],[6,5]);
var path = newSearch.search(grid);
console.log(path);