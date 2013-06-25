$(function(){
        
    String.prototype.insert = function (index, string) {
      if (index > 0)
        return this.substring(0, index) + string + this.substring(index, this.length);
      else
        return string + this;
    };
    
    var $elements=$(".uMail");
    var $subject=$(".uMailSubject");
    var $body=$(".uMailBody");
    
    $subject.hide();
    $body.hide();
    
    $elements.each(function(){
        var $thisElement=$(this);
        
        decodeElementText($thisElement);
    });
    
    function decodeElementText($thisElement){
        var options=eval($thisElement.attr('rel'));
        
        var decoded=options.lo.insert(options.sb, options.s).insert(options.a, '@');
        
        if($thisElement.is('a')){
            var href="mailto:"+decoded+"?subject="+$subject.text()+"&body="+$body.text();
            $thisElement.attr('href', href);
        }
        
        $thisElement.text(decoded);
    }
});