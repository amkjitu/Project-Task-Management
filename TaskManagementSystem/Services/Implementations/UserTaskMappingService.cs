using TaskManagementSystem.Models;
using TaskManagementSystem.Repositories.Interfaces;
using TaskManagementSystem.Services.Interfaces;

namespace TaskManagementSystem.Services.Implementations
    {
    public class UserTaskMappingService : IUserTaskMappingService
        {
        private readonly IUserTaskMappingRepository _repository;
        private readonly IGenericRepository<UserModel> _userRepository;
        private readonly IGenericRepository<TaskModel> _taskRepository;

        public UserTaskMappingService(
            IUserTaskMappingRepository repository,
            IGenericRepository<UserModel> userRepository,
            IGenericRepository<TaskModel> taskRepository)
            {
            _repository = repository;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            }

        public async Task<IEnumerable<UserTaskMappingModel>> GetAllMappingsAsync()
            {
            var mappings = await _repository.GetAllAsync();
            foreach (var mapping in mappings)
                {
                mapping.User = await _userRepository.GetByIdAsync(mapping.UserId);
                mapping.Task = await _taskRepository.GetByIdAsync(mapping.TaskId);
                }
            return mappings;
            }

        public async Task AddMappingAsync(UserTaskMappingModel mapping)
            {
            // Check if the same task is already assigned to the same user
            var existingMappings = await _repository.GetAllAsync();
            var existingMapping = existingMappings.FirstOrDefault(m => m.TaskId == mapping.TaskId && m.UserId == mapping.UserId);
            if (existingMapping != null)
                {
                throw new InvalidOperationException("This task is already assigned to the user.");
                }

            await _repository.AddAsync(mapping);
            }

        public async Task<UserTaskMappingModel?> GetMappingByIdAsync(int id)
            {
            var mapping = await _repository.GetByIdAsync(id);
            if (mapping != null)
                {
                mapping.User = await _userRepository.GetByIdAsync(mapping.UserId);
                mapping.Task = await _taskRepository.GetByIdAsync(mapping.TaskId);
                }
            return mapping;
            }

        public async Task UpdateMappingAsync(UserTaskMappingModel mapping)
            {
            await _repository.UpdateAsync(mapping);
            }

        public async Task DeleteMappingAsync(int id)
            {
            var mapping = await _repository.GetByIdAsync(id);
            if (mapping != null)
                {
                await _repository.DeleteAsync(mapping);
                }
            }
        }
    }


//using TaskManagementSystem.Models;
//using TaskManagementSystem.Repositories.Interfaces;
//using TaskManagementSystem.Services.Interfaces;

//namespace TaskManagementSystem.Services.Implementations
//    {
//    public class UserTaskMappingService : IUserTaskMappingService
//        {
//        private readonly IGenericRepository<UserTaskMappingModel> _repository;
//        private readonly IGenericRepository<UserModel> _userRepository;
//        private readonly IGenericRepository<TaskModel> _taskRepository;

//        public UserTaskMappingService(
//            IGenericRepository<UserTaskMappingModel> repository,
//            IGenericRepository<UserModel> userRepository,
//            IGenericRepository<TaskModel> taskRepository)
//            {
//            _repository = repository;
//            _userRepository = userRepository;
//            _taskRepository = taskRepository;
//            }

//        public async Task<IEnumerable<UserTaskMappingModel>> GetAllMappingsAsync()
//            {
//            var mappings = await _repository.GetAllAsync();
//            foreach (var mapping in mappings)
//                {
//                var user = await _userRepository.GetByIdAsync(mapping.UserId);
//                var task = await _taskRepository.GetByIdAsync(mapping.TaskId);
//                if (user != null && task != null)
//                    {
//                    mapping.User.Name = user.Name;
//                    mapping.Task.Title = task.Title;
//                    }
//                }
//            return mappings;
//            }

//        public async Task AddMappingAsync(UserTaskMappingModel mapping)
//            {
//            await _repository.AddAsync(mapping);
//            }

//        public async Task<UserTaskMappingModel?> GetMappingByIdAsync(int id)
//            {
//            var mapping = await _repository.GetByIdAsync(id);
//            if (mapping != null)
//                {
//                var user = await _userRepository.GetByIdAsync(mapping.UserId);
//                var task = await _taskRepository.GetByIdAsync(mapping.TaskId);
//                if (user != null && task != null)
//                    {
//                    mapping.User.Name = user.Name;
//                    mapping.Task.Title = task.Title;
//                    }
//                }
//            return mapping;
//            }

//        public async Task DeleteMappingAsync(int id)
//            {
//            var mapping = await _repository.GetByIdAsync(id);
//            if (mapping != null)
//                {
//                await _repository.DeleteAsync(mapping);
//                }
//            }
//        }
//}


//using TaskManagementSystem.Models;
//using TaskManagementSystem.Repositories.Interfaces;
//using TaskManagementSystem.Services.Interfaces;

//namespace TaskManagementSystem.Services.Implementations
//    {
//    public class UserTaskMappingService : IUserTaskMappingService
//        {
//        private readonly IUserTaskMappingRepository _mappingRepository;

//        public UserTaskMappingService(IUserTaskMappingRepository mappingRepository)
//            {
//            _mappingRepository = mappingRepository;
//            }

//        public async Task AssignTaskToUserAsync(int userId, int taskId)
//            {
//            var mapping = new UserTaskMappingModel
//                {
//                UserId = userId,
//                TaskId = taskId
//                };

//            await _mappingRepository.AddAsync(mapping);
//            }

//        public async Task<IEnumerable<UserTaskMappingModel>> GetUserTaskMappingsAsync()
//            {
//            return await _mappingRepository.GetAllAsync();
//            }
//        }
//    }
