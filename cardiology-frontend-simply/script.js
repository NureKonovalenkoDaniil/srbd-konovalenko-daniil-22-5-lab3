const baseUrl = 'https://localhost:7001/api';

document.getElementById('fetchDoctors').addEventListener('click', fetchDoctors);
document
  .getElementById('getPreparationsLessThanAvgPrice')
  .addEventListener('click', fetchPreparationsCount);
document.getElementById('deleteDoctors').addEventListener('click', deleteDoctors);

async function fetchDoctors() {
  try {
    console.log('Fetching doctors...');
    const response = await fetch(`${baseUrl}/Doctors`);
    console.log('Response status:', response.status);

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const responseData = await response.json();
    console.log('Doctors response:', responseData);

    const doctors = responseData.$values || responseData;
    console.log('Doctors array:', doctors);

    if (!Array.isArray(doctors)) {
      throw new Error('API did not return an array.');
    }

    const tableBody = document.querySelector('#doctorsTable tbody');
    tableBody.innerHTML = '';

    doctors.forEach((doctor) => {
      console.log('Adding doctor:', doctor);

      const row = `
                <tr>
                    <td>${doctor.doctorId || 'N/A'}</td>
                    <td>${doctor.fullName || 'N/A'}</td>
                    <td>${doctor.phoneNumber || 'N/A'}</td>
                    <td>${doctor.adress || 'N/A'}</td> <!-- Виправлено на "adress" -->
                    <td>${
                      doctor.position ? doctor.position.position1 : 'N/A'
                    }</td> <!-- Виправлено на "position1" -->
                </tr>
            `;
      tableBody.insertAdjacentHTML('beforeend', row);
    });

    showMessage('Лікарі завантажені успішно!', 'success');
  } catch (error) {
    console.error('Error fetching doctors:', error);
    showMessage('Помилка при завантаженні лікарів!', 'danger');
  }
}

async function fetchPreparationsCount() {
  try {
    const response = await fetch(`${baseUrl}/Preparations/less-than-avg-price`);
    const count = await response.json();

    document.getElementById('preparationsResult').innerText = `Кількість препаратів: ${count}`;
    showMessage('Дані отримано успішно!', 'success');
  } catch (error) {
    showMessage('Помилка при виконанні функції!', 'danger');
  }
}

async function deleteDoctors() {
  const minBeds = document.getElementById('minBeds').value;

  if (!minBeds) {
    showMessage('Вкажіть кількість ліжок!', 'warning');
    return;
  }

  try {
    const response = await fetch(`${baseUrl}/Doctors/delete-low-ward-beds?minBeds=${minBeds}`, {
      method: 'POST',
    });

    if (response.ok) {
      showMessage('Лікарі успішно видалені!', 'success');
    } else {
      showMessage('Помилка при видаленні лікарів!', 'danger');
    }
  } catch (error) {
    showMessage('Помилка під час виконання процедури!', 'danger');
  }
}

document.getElementById('addDoctorForm').addEventListener('submit', async function (e) {
  e.preventDefault();

  const fullName = document.getElementById('fullName').value;
  const phoneNumber = document.getElementById('phoneNumber').value;
  const adress = document.getElementById('adress').value;
  const positionName = document.getElementById('position').value;

  try {
    console.log('Sending doctor data...');

    const response = await fetch(`${baseUrl}/Doctors`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        fullName: fullName,
        phoneNumber: phoneNumber,
        adress: adress,
        position: { position1: positionName },
      }),
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const result = await response.json();
    console.log('Doctor added:', result);

    fetchDoctors();
    showMessage('Лікаря успішно додано!', 'success');

    document.getElementById('addDoctorForm').reset();
  } catch (error) {
    console.error('Error adding doctor:', error);
    showMessage('Помилка при додаванні лікаря!', 'danger');
  }
});

function showMessage(message, type) {
  const messageDiv = document.getElementById('messages');
  messageDiv.innerText = message;
  messageDiv.className = `alert alert-${type} mt-3`;
  messageDiv.classList.remove('d-none');
}
