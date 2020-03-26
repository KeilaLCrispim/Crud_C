$(document).ready(function(){
	// Activate tooltip
	$('[data-toggle="tooltip"]').tooltip();
	
	$('table .delete').on('click', function(){
		var id = $(this).parent().find('.id').val();
		$('#deleteEmployeeModal #idDelete').val(id);
	})

	$('table .edit').on('click', function(){
		var id = $(this).parent().find('.id').val();
		$.ajax({
			type: 'GET',
			url: '/Usuario/find/' + id,
			success: function(usuario){
				$('#editEmployeeModal #id').val(usuario.id);
				$('#editEmployeeModal #nomeUsuario').val(usuario.nomeUsuario);
				$('#editEmployeeModal #email').val(usuario.email);
				$('#editEmployeeModal #senha').val(usuario.senha);
			}
		})
	})

	// Select/Deselect checkboxes
	var checkbox = $('table tbody input[type="checkbox"]');
	$("#selectAll").click(function(){
		if(this.checked){
			checkbox.each(function(){
				this.checked = true;                        
			});
		} else{
			checkbox.each(function(){
				this.checked = false;                        
			});
		} 
	});
	checkbox.click(function(){
		if(!this.checked){
			$("#selectAll").prop("checked", false);
		}
	});

	function toggleAlert(){
		$(".alert").toggleClass('in out'); 
		return false; // Keep close.bs.alert event from removing from DOM
	}
	

});