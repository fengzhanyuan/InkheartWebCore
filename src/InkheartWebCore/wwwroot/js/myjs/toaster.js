var toatster = function (data) {
        $.toast({
            heading: data.head,
            text: data.text,
            icon: data.icon,
            position: 'mid-center',
            loader: false,
            hideAfter: 700    
    })
}