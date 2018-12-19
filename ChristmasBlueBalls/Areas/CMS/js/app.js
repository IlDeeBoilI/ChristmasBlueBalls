RightPanelFix();

function RightPanelFix(){
    var leftPanel = document.getElementById("leftPanel");
    var leftPanelWidth = document.getElementById("leftPanel").offsetWidth;
    var navLinks = document.getElementsByClassName("navLinkText");

    var rightPanel = document.getElementById("rightPanel");

    

    if(window.innerWidth >= 768){
        rightPanel.style.width = window.innerWidth - leftPanelWidth.toString() + "px";
        rightPanel.style.marginLeft = leftPanelWidth.toString() + "px";

        if(window.innerWidth < rightPanel.offsetWidth){
            rightPanel.style.marginLeft = leftPanelWidth.toString() + "px";
            rightPanel.style.width = "100%";
        }
    }
    else if(window.innerWidth < 768){
        rightPanel.style.width = window.innerWidth + "px";
        rightPanel.style.paddingLeft = "15px";
        rightPanel.style.paddingRight = "15px";
        rightPanel.style.marginLeft = "0";
    }
}